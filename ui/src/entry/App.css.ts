import { globalStyle, style, styleVariants } from '@vanilla-extract/css';

globalStyle('body', {
    height: '100vh',
    width: '100vw',
    overflow: 'auto',
    boxSizing: 'border-box',
    fontSize: '16px',
});

globalStyle('#root', {
    height: '100%',
    width: '100%',
});

export const appLayout = style({
    display: 'grid',
    gridTemplateColumns: 'auto',
    gridTemplateRows: 'auto 1fr',
    height: '100%',
    width: '100%',
});

globalStyle(`${appLayout} nav`, {
    display: 'flex',
    columnGap: '.5rem',
    padding: '.25rem .5rem',
});

export const navLink = styleVariants({
    active: {
        color: 'LinkText',
    },
    inactive: {
        color: 'CanvasText',
    },
});
