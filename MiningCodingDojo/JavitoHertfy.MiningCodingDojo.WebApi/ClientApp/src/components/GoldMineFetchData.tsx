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
                <h1 id="tabelLabel">Mining Contest Ranking</h1>                
                {this.renderForecastsTable()}             
            </React.Fragment>
        );
    }

    private ensureDataFetched() {      
        this.props.requestGoldMine();
    }

    private renderForecastsTable() {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Gold Left</th>                              
                    </tr>
                </thead>
                <tbody>
                    <tr key={this.props.goldMine.id}>
                        <td> {this.props.goldMine.goldLeft}</td>                       
                    </tr>
                   
                </tbody>
            </table>
        );
    }
   
}

export default connect(
    (state: ApplicationState) => state.goldMine, // Selects which state properties are merged into the component's props
    GoldMineStore.actionCreators // Selects which action creators are merged into the component's props
)(GoldMineFetchData as any);
