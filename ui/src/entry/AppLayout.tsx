import { Outlet } from 'react-router';
import { appLayout } from './App.css';
import { NavItem } from './NavItem';

export const AppLayout = () => (
    <div className={appLayout}>
        <nav>
            <NavItem to='/'>Home</NavItem>
            <NavItem to='/extractors'>Extractors</NavItem>
            <NavItem to='/processors'>Processors</NavItem>
            <NavItem to='/transports'>Transports</NavItem>
            <NavItem to='/consumers'>Consumers</NavItem>
        </nav>
        <Outlet />
    </div>
);