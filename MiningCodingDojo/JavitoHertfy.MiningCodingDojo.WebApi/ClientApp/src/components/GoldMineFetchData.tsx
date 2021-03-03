import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../store';
import * as GoldMineStore from '../store/GoldMine';


// At runtime, Redux will merge together...
type GoldMineProps =  
    GoldMineStore.GoldMineState
    & typeof GoldMineStore.actionCreators// ... plus action creators we've requested

class GoldMineFetchData extends React.PureComponent<GoldMineProps> {
    // This method is called when the component is first added to the document
    public componentDidMount() {
        this.ensureDataFetched();
    }

    // This method is called when the route parameters change
    public componentDidUpdate() {
        this.ensureDataFetched();
    }

    public render() {
        return (
            <React.Fragment>                             
                {this.renderGoldMine()}             
            </React.Fragment>
        );
    }

    private ensureDataFetched() {      
        this.props.requestGoldMine();
    }

    private renderGoldMine() {
        return (
            <div className="goldMine">Gold Mine Left: {this.props.goldMine.goldLeft}</div>          
        );
    }
   
}

export default connect(
    (state: ApplicationState) => state.goldMine, // Selects which state properties are merged into the component's props
    GoldMineStore.actionCreators // Selects which action creators are merged into the component's props
)(GoldMineFetchData as any);
