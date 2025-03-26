import { BrowserRouter } from 'react-router';
import { Suspense } from 'react';
import { AppRouting } from './entry/AppRouting';
import { TitleProvider } from 'entry/TitleProvider';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';

const queryClient = new QueryClient();

export const App = () => (
    <Suspense fallback={<p>Loading...</p>}>
        <QueryClientProvider client={queryClient} >
            <BrowserRouter>
                <TitleProvider>
                    <AppRouting />
                </TitleProvider>
            </BrowserRouter>
        </QueryClientProvider>
    </Suspense>
);