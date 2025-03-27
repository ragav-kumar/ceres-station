import { ColumnDto } from 'api';
import styles from './Table.module.css';

interface HeaderCellProps {
    column: ColumnDto;
}

export const HeaderCell = ( { column }: HeaderCellProps) => (
    <th
        className={styles.headerCell}
        style={{ width: column.width || undefined, maxWidth: column.width || undefined }}
    >
        {column.displayName}
    </th>
);