import { useQuery } from 'api';
import { Row } from './Row.tsx';
import styles from './Table.module.css';

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
                <thead>
                <tr>
                    {columns.map(( column, index ) => (
                        <th key={index} style={{ width: column.width || undefined }}>{column.displayName}</th>
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
    const { data, isLoading: isLoadingData } = useQuery('get', '/api/List/{entityTypeName}', {
        params: {
            path: {
                entityTypeName,
            }
        },
    });
    const { data: columns, isLoading: isLoadingColumns } = useQuery('get', '/api/List/{entityTypeName}/Columns', {
        params: {
            path: {
                entityTypeName,
            }
        }
    });

    return {
        data,
        columns,
        isLoading: isLoadingData || isLoadingColumns,
    };
};