import { ColumnDto, ListRowDto } from 'api/dto.ts';
import { ReactNode } from 'react';

interface RowProps {
    row: ListRowDto;
    columns: ColumnDto[];
}

export const Row = ({row, columns}: RowProps) => {
    const cells: ReactNode[] = [];
    for (const column of columns) {
        if (column.fieldName) {
            cells.push(
                <td key={column.fieldName} style={{ textAlign: 'center' }}>
                    {row[column.fieldName] as ReactNode}
                </td>,
            );
        }
    }

    return (
        <tr>
            {cells}
        </tr>
    );
};