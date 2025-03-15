import styles from './Toolbar.module.css';
import { ReactNode } from 'react';

interface ToolbarProps {
    children: ReactNode;
}

export const Toolbar = ({children}: ToolbarProps) => (
    <div className={styles.wrap}>
        {children}
    </div>
);