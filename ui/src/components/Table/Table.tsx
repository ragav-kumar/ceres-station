import { useEffect, useState } from 'react';
import { ColumnDto, ListDataDto } from 'api/dto.ts';
import { Api } from 'api/sdk.ts';
import { Row } from './Row.tsx';
import { tableStyle, tableWrapperStyle } from './Table.css.ts';

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

    console.log({data, columns});

    if (data == null || columns == null) {
        return null;
    }

    return (
        <div className={tableWrapperStyle}>
            <table className={tableStyle}>
                <thead>
                <tr>
                    {columns.map((column, index) => (
                        <th key={index} style={{ width: column.width }}>{column.displayName}</th>
                    ))}
                </tr>
                </thead>
                <tbody>
                {data.rows.map((row, index) => (
                    <Row key={index} row={row} columns={columns}/>
                ))}
                </tbody>
            </table>
        </div>
    );
};