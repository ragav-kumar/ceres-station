import styles from './Nav.module.css';
import { joinClassNames } from 'utilities';

interface SideNavProps {
    className?: string;
}

/**
 * Rather than a true navigation, this will be a data feed.
 * For now, just render an empty <ul>
 */
export const SideNav = ({className}: SideNavProps) => (
    <ul className={joinClassNames(styles.sideNav, className)}>
        <li>[Feed offline]</li>
    </ul>
);