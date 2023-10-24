import React from 'react';

export default function Container(props) {
    return (
        <div style={{
            display: 'flex',
            justifyContent: 'center',
            alignItems: 'center',
            padding: 10,
            border: '1px solid red'
        }}>{props.children}</div>
    );
}