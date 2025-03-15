import { Outlet } from 'react-router';
import styles from './App.module.css';
import { SideNav, TopNav } from 'components/Nav';

export const AppLayout = () => (
    <div className={styles.appLayout}>
        <TopNav className={styles.topArea} />
        <SideNav className={styles.leftArea} />
        <div className={styles.contentArea}>
            <Outlet />
        </div>
    </div>
);