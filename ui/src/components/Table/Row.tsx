import { ReactNode } from 'react';
import styles from './Table.module.css';
import paths from 'schema';
type ColumnDto = paths.components['schemas']['ColumnDto'];

interface RowProps {
    row: Record<string, unknown>;
    columns: ColumnDto[];
}

export const Row = ({row, columns}: RowProps) => {
    const cells: ReactNode[] = [];
    for (const column of columns) {
        if (column.fieldName) {
            cells.push(
                <td key={column.fieldName} className={styles.cell} style={{ width: column.width || undefined }}>
                    {row[column.fieldName] as ReactNode}
                </td>,
            );
        }
    }

    return (
        <tr className={styles.row}>
            {cells}
        </tr>
    );
};