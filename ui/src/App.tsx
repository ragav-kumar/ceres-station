import { BrowserRouter } from 'react-router';
import { Suspense } from 'react';
import { AppRouting } from './entry/AppRouting';
import { TitleProvider } from './entry/TitleContext';

export const App = () => (
    <Suspense fallback={<p>Loading...</p>}>
        <BrowserRouter>
            <TitleProvider>
                <AppRouting />
            </TitleProvider>
        </BrowserRouter>
    </Suspense>
);