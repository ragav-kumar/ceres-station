import { NavLink, To } from 'react-router';
import { ReactNode } from 'react';
import styles from './Nav.module.css';
import { joinClassNames } from 'utilities/utilities';

interface NavItemProps {
    to: To;
    children: ReactNode;
}

export const NavItem = ({children, to}: NavItemProps) => (
    <NavLink
        to={to}
        className={props => joinClassNames(styles.navLink, props.isActive ? styles.active : styles.inactive)}
    >
        {children}
    </NavLink>
);