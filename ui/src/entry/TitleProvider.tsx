import { ReactNode, useState } from 'react';
import { TitleContext } from './TitleContext';

const baseTitle = 'Ceres Station';

export const TitleProvider = ({children}: { children: ReactNode }) => {
    const [title, setTitle] = useState<string>(baseTitle);

    const set = (newTitle: string) => {
        if (newTitle.trim() === '') {
            setTitle(baseTitle);
        } else {
            setTitle(`${baseTitle} - ${newTitle}`);
        }
    };

    return (
        <TitleContext value={{set}}>
            <title>{title}</title>
            {children}
        </TitleContext>
    );
};