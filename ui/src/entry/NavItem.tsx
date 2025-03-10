import { NavLink, To } from 'react-router';
import { ReactNode } from 'react';
import { navLink } from './App.css';

interface NavItemProps {
    to: To;
    children: ReactNode;
}

export const NavItem = ({children, to}: NavItemProps) => (
    <NavLink
        to={to}
        className={props => navLink[props.isActive ? 'active' : 'inactive']}
    >
        {children}
    </NavLink>
);