import { ReactNode } from 'react';
import styles from 'components/Table/Table.module.css';
import { isEntityDto, isReactNode, isResourceDto } from 'utilities';

interface CellProps {
    width: number | undefined;
    children: unknown;
}

export const Cell = ( { children, width }: CellProps) => {
    let rendered: ReactNode;
    
    if (isReactNode(children)) {
        rendered = children;
    } else if (isEntityDto(children) || isResourceDto(children)) {
        rendered = children.name;
    }

    return (
        <td
            className={styles.cell}
            style={{ width, maxWidth: width }}
        >
            {rendered}
        </td>
    );
};