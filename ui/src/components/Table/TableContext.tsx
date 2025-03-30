import { createContext, useContext, MouseEvent as ReactMouseEvent } from 'react';

export interface TableContextType {
    getWidth: (columnId: string) => number;
    updateWidth: (columnId: string, width: number) => void;
    onColumnResize: (columnId: string, event: ReactMouseEvent<HTMLDivElement, MouseEvent>) => void;
    isResizable: boolean;
}

export const TableContext = createContext<TableContextType | undefined>(undefined);

export const useTableContext = () => {
    const context = useContext(TableContext);

    if (context == null) {
        throw new Error('Attempted to use TableContext outside a table.');
    }

    return context;
};