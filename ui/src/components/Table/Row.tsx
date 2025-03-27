import { ReactNode } from 'react';
import styles from './Table.module.css';
import { ColumnDto } from 'api';
import { Cell } from 'components/Table/Cell.tsx';

interface RowProps {
    row: Record<string, unknown>;
    columns: ColumnDto[];
}

export const Row = ({row, columns}: RowProps) => {
    const cells: ReactNode[] = [];
    for (const column of columns) {
        if (column.fieldName) {
            cells.push(
                <Cell key={`${column.fieldName}_${row[column.fieldName]}`} width={column.width || undefined}>
                    {row[column.fieldName]}
                </Cell>
            );
        }
    }

    return (
        <tr className={styles.row}>
            {cells}
        </tr>
    );
};