import React from 'react';
import '../styles/Container.css';

export default function Container({children, style, className}) {
    return (
        <div className={`app-container ${className}`} style={style}>{children}</div>
    );
}
