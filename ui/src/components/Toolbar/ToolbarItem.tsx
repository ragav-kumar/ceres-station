import { ReactNode } from 'react';
import styles from './Toolbar.module.css';
import { joinClassNames } from 'utilities';

interface ToolbarItemProps {
    tooltipText: string;
    isActive?: boolean;
    isDisabled?: boolean;
    onClick: () => void;
    // Rendered content, usually an icon
    children: ReactNode;
}

export const ToolbarItem = ({children, isActive, isDisabled, onClick, tooltipText}: ToolbarItemProps) => (
    <button
        disabled={isDisabled}
        className={joinClassNames(styles.button, isActive ? styles.active : undefined)}
        onClick={onClick}
        title={tooltipText}
    >
        {children}
    </button>
);