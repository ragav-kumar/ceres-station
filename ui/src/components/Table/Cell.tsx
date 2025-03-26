import { ColumnDto } from 'api';
import { isValidElement, ReactNode } from 'react';
import styles from 'components/Table/Table.module.css';
import { isEntityDto } from 'utilities';

interface CellProps {
    column: ColumnDto;
    children: unknown;
}

export const Cell = ( { column, children }: CellProps) => {
    let rendered: ReactNode;
    
    if (children == null || isValidElement(children)) {
        rendered = children;
    } else if (isEntityDto(children)) {
        rendered = children.name;
    }

    return (
        <td
            className={styles.cell}
            style={{ width: column.width || undefined }}
        >
            {rendered}
        </td>
    );
};