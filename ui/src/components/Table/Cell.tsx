import { ReactNode } from 'react';
import styles from 'components/Table/Table.module.css';
import { isEntityDto, isReactNode, isResourceDto } from 'utilities';
import { useTableContext } from './TableContext';

interface CellProps {
    columnId: string;
    children: unknown;
}

export const Cell = ({children, columnId}: CellProps) => {
    const width = useTableContext().getWidth(columnId);

    let rendered: ReactNode;

    if (isReactNode(children)) {
        rendered = children;
    } else if (isEntityDto(children) || isResourceDto(children)) {
        rendered = children.name;
    }

    return (
        <td
            className={styles.cell}
            style={{width, maxWidth: width}}
        >
            {rendered}
        </td>
    );
};