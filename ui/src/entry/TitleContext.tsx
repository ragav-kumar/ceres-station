import { createContext, useContext, useEffect } from 'react';

export interface TitleContextType {
    set: (title: string) => void;
}

export const TitleContext = createContext<TitleContextType | undefined>(undefined);

export const useTitle = (newTitle: string) => {
    const context = useContext(TitleContext);
    if (!context) {
        throw new Error('useTitle must be used within TitleContext');
    }

    useEffect(() => {
        context.set(newTitle);
    }, [newTitle]);
};

