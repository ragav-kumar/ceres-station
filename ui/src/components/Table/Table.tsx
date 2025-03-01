import { ColumnDto } from 'api';

interface TableProps<T extends object> {
    fetchData: () => Promise<T[]>;
    fetchColumns: () => Promise<ColumnDto[]>;
}

export const Table = <T extends object>({fetchColumns, fetchData}: TableProps<T>) => {

    return (
        <p>TODO</p>
    );
};