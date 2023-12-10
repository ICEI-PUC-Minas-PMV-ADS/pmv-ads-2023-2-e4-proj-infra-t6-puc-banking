import React from 'react';
import { BottomNavigation } from 'react-native-paper';
import HomePage from '../pages/HomePage';
import BillPage from '../pages/BillPage';

export function Tabbar({ navigation }) {
    const [index, setIndex] = React.useState(0);
    const [routes] = React.useState([
        { key: 'home', focusedIcon: 'home', unfocusedIcon: 'home' },
        { key: 'bill', focusedIcon: 'view-list', unfocusedIcon: 'view-list' }
    ]);

    const HomeRoute = () => <HomePage navigation={navigation}></HomePage>
    const BillRoute = () => <BillPage navigation={navigation}></BillPage>

    const renderScene = BottomNavigation.SceneMap({
        home: HomeRoute,
        bill: BillRoute
    });

    return (
        <BottomNavigation style={{ justifyContent: 'flex-start', height: '100%' }} barStyle={{ justifyContent: 'flex-start', backgroundColor: '#7076F4', height: 60, }} activeColor='#969BF7' inactiveColor='#B8BCFC'
            navigationState={{ index, routes }}
            onIndexChange={setIndex}
            renderScene={renderScene}
        />
    );
}

