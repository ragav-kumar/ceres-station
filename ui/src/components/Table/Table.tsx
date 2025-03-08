import { useEffect, useState } from 'react';
import { ColumnDto, ListDataDto } from 'api/dto.ts';
import { Api } from 'api/sdk.ts';
import { Row } from './Row.tsx';

interface TableProps {
    entity: string;
}

export const Table = ({entity}: TableProps) => {
    const [data, setData] = useState<ListDataDto | undefined>(undefined);
    const [columns, setColumns] = useState<ColumnDto[] | undefined>(undefined);

    useEffect(() => {
        Api.List.GetData(entity).then(setData);
        Api.List.GetColumns(entity).then(setColumns);
    }, [entity]);

    console.log({ data, columns });

    if (data == null || columns == null) {
        return null;
    }

    return (
        <table>
            <thead>
            <tr>
                {columns.map((column, index) => (
                    <th key={index}>{column.displayName}</th>
                ))}
            </tr>
            </thead>
            <tbody>
            {data.rows.map((row, index) => (
                <Row key={index} row={row} columns={columns} />
            ))}
            </tbody>
        </table>
    );
};