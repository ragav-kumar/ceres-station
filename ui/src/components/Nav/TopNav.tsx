import { NavItem } from './NavItem';
import styles from './Nav.module.css';
import { joinClassNames } from 'utilities';
import { useQuery } from 'api';

interface TopNavProps {
    className?: string;
}

export const TopNav = ({className}: TopNavProps) => {
    const { data: money = 0, isLoading } = useQuery('get', '/api/Settings/Money');

    return (
        <div className={joinClassNames(styles.topNavWrap, className)}>
            <nav className={styles.topNav}>
                <NavItem to="/extractors">Extractors</NavItem>
                <NavItem to="/processors">Processors</NavItem>
                <NavItem to="/transports">Transports</NavItem>
                <NavItem to="/consumers">Consumers</NavItem>
            </nav>
            <div className={styles.money}>
                {isLoading ? 'Checking bank account...' : money}
            </div>
        </div>
    );
};