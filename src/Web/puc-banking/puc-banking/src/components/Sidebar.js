import React, { useState, useEffect } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-icons/font/bootstrap-icons.css';
import 'bootstrap/js/dist/dropdown';
import '../styles/Sidebar.css';
import PucLogo from '../assets/puc-logo-light.png';

export default function Sidebar({ sidebarItems, navigate, username, profileCallback, logoutCallback }) {

    const [currentPage, setCurrentPage] = useState(undefined);

    function handleCLick(tag) {
        if (currentPage !== tag) {
            const item = sidebarItems.find((x) => x.tag === tag);
            const itemPage = item.page;

            if(navigate(itemPage)) {
                setCurrentPage(tag);
            }
        }
    }

    useEffect(() => {

        const item = sidebarItems.find((x) => x.tag === 'home');
        const itemPage = item.page;

        if(navigate(itemPage)) {
            setCurrentPage('home');
        }
    });

    return (
        <div>
            <div>
                <div className="col-auto px-2 app-bg-primary d-flex flex-column justify-content-between min-vh-100">
                    <div className="mt-2">
                        <a className="text-decoration-none d-flex align-items-center w-100 text-white d-none d-sm-inline" role="button">
                            <img className="img-fluid" style={{width: '100px'}}  src={PucLogo}/>
                        </a>
                        <hr className="text-white d-none d-sm-block"></hr>
                        <ul className="nav nav-pills flex-column" id="parentM">
                            {
                                sidebarItems.map((item) => {
                                    return (
                                    <li className="nav-item my-1 py-2 py-sm-0">
                                        <a onClick={() => { handleCLick(item.tag) }} className={`nav-link text-white text-center text-sm-start ${currentPage === item.tag ? 'app-item-active' : '' }`} aria-current="page" role="button">
                                            <i className={`bi ${item.iconClass}`}></i>
                                            <span className="ms-2 d-none d-sm-inline sidebar-item-title">{item.title}</span>
                                        </a>
                                    </li>
                                    );
                                })
                            }

                        </ul>
                    </div>
                    <div className="dropdown open mb-2">
                        <a className="btn border-none dropdown-toggle text-white" type="button" id="triggerId" data-bs-toggle="dropdown" aria-haspopup="true"
                            aria-expanded="false">
                                <i className="bi bi-person fs-5"></i><span className="fs-6 ms-3 d-none d-sm-inline sidebar-profile-username">{username}</span>
                        </a>
                        <div className="dropdown-menu" aria-labelledby="triggerId">
                            <a className="dropdown-item" onClick={profileCallback} role="button">
                                <i className="bi bi-person fs-5"></i>
                                <span className="ms-1">Profile</span>
                            </a>
                            <a className="dropdown-item" onClick={logoutCallback} role="button">
                                <i className="bi bi-door-closed fs-5"></i>
                                <span className="ms-1">Logout</span>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}
