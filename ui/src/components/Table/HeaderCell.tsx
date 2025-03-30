import { ColumnDto } from 'api';
import styles from './Table.module.css';
import { useTableContext } from './TableContext';

interface HeaderCellProps {
    column: ColumnDto;
}

export const HeaderCell = ({column}: HeaderCellProps) => {
    const {getWidth, isResizable, onColumnResize} = useTableContext();
    const width = getWidth(column.id!);

    return (
        <th
            className={styles.headerCell}
            style={{
                width,
                maxWidth: width,
            }}
        >
            {column.displayName}
            {isResizable ? (
                <div
                    className={styles.resizer}
                    onMouseDown={e => onColumnResize(column.id!, e)}
                />
            ) : null}
        </th>
    );
};