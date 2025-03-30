import { useQuery } from 'api';
import { Row } from './Row.tsx';
import styles from './Table.module.css';
import { MouseEvent as ReactMouseEvent, useEffect, useMemo, useRef, useState } from 'react';
import { toast } from 'react-toastify';
import { TableContext } from './TableContext';
import { toDictionary } from 'utilities/utilities';
import { TableHeader } from './TableHeader';

interface TableProps {
    entity: string;
    isResizable?: boolean;
}

const MIN_COLUMN_WIDTH = 25;

export const Table = ({entity, isResizable = true}: TableProps) => {
    const [columnWidths, setColumnWidths] = useState<Record<string, number>>(Object.create(null));
    const resizingColumn = useRef<string | null>(null);
    const startX = useRef<number>(0);
    const startWidth = useRef<number>(0);

    const {data, columns, isLoading} = useTableData(entity);
    const tableWidth = useMemo(() => {
        let width = 0;

        for (const colId in columnWidths) {
            if (Object.hasOwn(columnWidths, colId) && columnWidths[colId] != null) {
                width += columnWidths[colId];
            }
        }

        return width;
    }, [columnWidths]);

    const getWidth = (columnId: string) => columnWidths[columnId] ?? 100;
    const updateWidth = (columnId: string, width: number) => {
        setColumnWidths(w => ({
            ...w,
            [columnId]: width,
        }));
    };
    const columnResized = (columnId: string, e: ReactMouseEvent<HTMLDivElement, MouseEvent>) => {
        resizingColumn.current = columnId;
        startX.current = e.clientX;
        startWidth.current = columnWidths[columnId] ?? 0;

        document.addEventListener('mousemove', mouseMoved);
        document.addEventListener('mouseup', mouseUp);
    };

    // Update widths
    const mouseMoved = (e: MouseEvent) => {
        if (!resizingColumn.current) {
            return;
        }
        const delta = e.clientX - startX.current;
        setColumnWidths(c => ({
            ...c,
            [resizingColumn.current!]: Math.max(startWidth.current + delta, MIN_COLUMN_WIDTH),
        }));
    };

    // Cleanup
    const mouseUp = () => {
        resizingColumn.current = null;
        document.removeEventListener('mousemove', mouseMoved);
        document.removeEventListener('mouseup', mouseUp);
    };

    useEffect(() => {
        if (columns) {
            setColumnWidths(toDictionary(
                columns,
                col => col.id!,
                col => col.width ?? 100,
            ));
        } else {
            setColumnWidths(Object.create(null));
        }
    }, [columns]);

    if (isLoading) {
        return <div>Loading...</div>;
    }
    if (columns == null || data == null) {
        return null;
    }
    return (
        <TableContext
            value={{
                getWidth,
                updateWidth,
                isResizable,
                onColumnResize: columnResized,
            }}
        >
            <div className={styles.wrap}>
                <table className={styles.table} style={{ minWidth: tableWidth }}>
                    <TableHeader columns={columns} />
                    <tbody>
                    {data.rows?.map((row, index) => (
                        <Row key={index} row={row} columns={columns}/>
                    ))}
                    </tbody>
                </table>
            </div>
        </TableContext>
    );
};

const useTableData = (entityTypeName: string) => {
    const {
        data,
        isLoading: isLoadingData,
        error: dataError,
    } = useQuery('get', '/api/List/{entityTypeName}', {
        params: {
            path: {
                entityTypeName,
            },
        },
    });
    const {
        data: columns,
        isLoading: isLoadingColumns,
        error: columnsError,
    } = useQuery('get', '/api/List/{entityTypeName}/Columns', {
        params: {
            path: {
                entityTypeName,
            },
        },
    });

    useEffect(() => {
        if (dataError != null) {
            console.error('Failed to fetch data:', dataError);
            toast.error(<span>{dataError}</span>);
        }
    }, [dataError]);

    useEffect(() => {
        if (columnsError != null) {
            console.error('Failed to fetch columns:', columnsError);
            toast.error(<span>{columnsError}</span>);
        }
    }, [columnsError]);

    return {
        data,
        columns,
        isLoading: isLoadingData || isLoadingColumns,
    };
};