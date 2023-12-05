import React, { useState } from "react";
import Sidebar from './Sidebar';
import HomePage from '../pages/HomePage';
import 'bootstrap/dist/css/bootstrap.min.css';
import { useAuth } from '../hooks/useAuth';
import { useUser } from '../hooks/useUser';
import { useInitialRender } from "../hooks/useInitialRender";
import EventProvider from '../utils/EventProvider';

const sidebarItems = [
    {
      tag: 'home',
      title: 'Home',
      page: <HomePage></HomePage>,
      iconClass: 'bi-house'
    }
  ];


export default function Shell() {

    const { logout } = useAuth();
    const { userData } = useUser();
    const [currentPage, setCurrentPage] = useState(undefined);

    function navigate(page) {
        if (currentPage !== page) {
            setCurrentPage(page);

            return true;
        }

        return false;
    }

    return (
        <div className="d-flex vw-100 vh-100">
            <Sidebar sidebarItems={sidebarItems} username={userData.name} navigate={navigate} profileCallback={() => {}} logoutCallback={logout}/>
            <div className="vw-100 vh-100 overflow-auto">{currentPage}</div>
        </div>
    );
}
