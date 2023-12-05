import React from "react";

export default function LoadingPage() {
    return (
        <div className="spinner-border fs-4" style={{width: '3em', height: '3em', color: 'var(--colors-primary-400)'}} role="status"></div>
    );
}
