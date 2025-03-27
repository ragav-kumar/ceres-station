import { useQuery } from 'api';
import { Row } from './Row.tsx';
import styles from './Table.module.css';
import { useEffect } from 'react';
import { toast } from 'react-toastify';
import { HeaderCell } from 'components/Table/HeaderCell';

interface TableProps {
    entity: string;
}

export const Table = ( { entity }: TableProps ) => {
    const { data, columns, isLoading } = useTableData(entity);

    if ( isLoading || columns == null || data == null ) {
        return null;
    }

    return (
        <div className={styles.wrap}>
            <table className={styles.table}>
                <colgroup>
                    {columns.map(column => (
                        <col key={column.id} style={{ width: column.width || undefined }} />
                    ))}
                </colgroup>
                <thead>
                <tr>
                    {columns.map(( column, index ) => (
                        <HeaderCell key={index} column={column} />
                    ))}
                </tr>
                </thead>
                <tbody>
                {data.rows?.map(( row, index ) => (
                    <Row key={index} row={row} columns={columns}/>
                ))}
                </tbody>
            </table>
        </div>
    );
};

const useTableData = ( entityTypeName: string ) => {
    const {
        data,
        isLoading: isLoadingData,
        error: dataError,
    } = useQuery('get', '/api/List/{entityTypeName}', {
        params: {
            path: {
                entityTypeName,
            }
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
            }
        }
    });

    useEffect(() => {
        if (dataError != null) {
            console.error('Failed to fetch data:', dataError);
            toast.error(<span>{dataError}</span>);
        }
    }, [ dataError ]);

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