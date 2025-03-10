import { Route, Routes } from 'react-router';
import { AppLayout } from './AppLayout';
import { GenericListPage } from '../pages/GenericListPage';

export const AppRouting = () => (
    <Routes>
        <Route element={<AppLayout />}>
            <Route path='/' element={<>TODO</>} />
            <Route path='extractors'>
                <Route index element={<GenericListPage entity='Extractors' />} />
            </Route>
            <Route path='processors'>
                <Route index element={<GenericListPage entity='Processors' />} />
            </Route>
            <Route path='transports'>
                <Route index element={<GenericListPage entity='Transports' />} />
            </Route>
            <Route path='consumers'>
                <Route index element={<GenericListPage entity='Consumers' />} />
            </Route>
        </Route>
    </Routes>
);