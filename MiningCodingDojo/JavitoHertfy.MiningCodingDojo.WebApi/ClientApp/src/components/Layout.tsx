import * as React from 'react';
import { Container } from 'reactstrap';
import GoldMineFetchData from './GoldMineFetchData';
import NavMenu from './NavMenu';

export default (props: { children?: React.ReactNode }) => (
    <React.Fragment>
        <NavMenu />
        <GoldMineFetchData />
        <Container>
            {props.children}
        </Container>
    </React.Fragment>
);
