import { ColumnDto } from 'api';
import { ReactNode } from 'react';
import styles from 'components/Table/Table.module.css';
import { isEntityDto, isReactNode, isResourceDto } from 'utilities';

interface CellProps {
    column: ColumnDto;
    children: unknown;
}

export const Cell = ( { column, children }: CellProps) => {
    let rendered: ReactNode;
    
    if (isReactNode(children)) {
        rendered = children;
    } else if (isEntityDto(children) || isResourceDto(children)) {
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