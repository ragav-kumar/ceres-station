import { Outlet } from 'react-router';
import styles from './App.module.css';
import { SideNav, TopNav } from 'components/Nav';
import { ToastContainer } from 'react-toastify';

export const AppLayout = () => (
    <div className={styles.appLayout}>
        <ToastContainer
            className={styles.toastContainer}
            autoClose={false}
            position='top-center'
            closeOnClick
            newestOnTop
            hideProgressBar
            role='error'
        />
        <TopNav className={styles.topArea} />
        <SideNav className={styles.leftArea} />
        <div className={styles.contentArea}>
            <Outlet />
        </div>
    </div>
);