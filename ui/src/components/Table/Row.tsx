import { ColumnDto, ListRowDto } from 'api/dto.ts';
import { ReactNode } from 'react';
import { cellStyle, rowStyle } from './Table.css.ts';

interface RowProps {
    row: ListRowDto;
    columns: ColumnDto[];
}

export const Row = ({row, columns}: RowProps) => {
    const cells: ReactNode[] = [];
    for (const column of columns) {
        if (column.fieldName) {
            cells.push(
                <td key={column.fieldName} className={cellStyle} style={{ width: column.width }}>
                    {row[column.fieldName] as ReactNode}
                </td>,
            );
        }
    }

    return (
        <tr className={rowStyle}>
            {cells}
        </tr>
    );
};