import { createContext, ReactNode, useContext, useState } from 'react';

export interface TitleContextType {
    set: (title: string) => void;
}

const TitleContext = createContext<TitleContextType | undefined>(undefined);

export const useTitle = (newTitle: string) => {
    const context = useContext(TitleContext);
    if (!context) {
        throw new Error('useTitle must be used within TitleContext');
    }
    context.set(newTitle);
};

const baseTitle = 'Ceres Station';

export const TitleProvider = ({ children }: { children: ReactNode }) => {
    const [title, setTitle] = useState<string>(baseTitle);

    const set = (newTitle: string) => {
        setTitle(`${baseTitle} - ${newTitle}`);
    };

    return (
        <TitleContext value={{ set }}>
            <title>{title}</title>
            {children}
        </TitleContext>
    );
};