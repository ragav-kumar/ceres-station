import { NavItem } from './NavItem';
import styles from './Nav.module.css';
import { joinClassNames } from 'utilities';

interface TopNavProps {
    className?: string;
}

export const TopNav = ({className}: TopNavProps) => (
    <nav className={joinClassNames(styles.topNav, className)}>
        <NavItem to="/extractors">Extractors</NavItem>
        <NavItem to="/processors">Processors</NavItem>
        <NavItem to="/transports">Transports</NavItem>
        <NavItem to="/consumers">Consumers</NavItem>
    </nav>
);