import { createContext, useContext } from 'react';

export interface TitleContextType {
    set: (title: string) => void;
}

export const TitleContext = createContext<TitleContextType | undefined>(undefined);

export const useTitle = (newTitle: string) => {
    const context = useContext(TitleContext);
    if (!context) {
        throw new Error('useTitle must be used within TitleContext');
    }
    context.set(newTitle);
};

