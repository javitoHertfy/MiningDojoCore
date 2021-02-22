import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../store';
import * as MinersStore from '../store/Miners';

// At runtime, Redux will merge together...
type WeatherForecastProps =
    MinersStore.MinersState // ... state we've requested from the Redux store
    & typeof MinersStore.actionCreators // ... plus action creators we've requested
    & RouteComponentProps<{ startDateIndex: string }>; // ... plus incoming routing parameters


class FetchData extends React.PureComponent<WeatherForecastProps> {
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
        this.props.requestMiners();
    }

    private renderForecastsTable() {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Gold mined</th>      
                        <th>Is Logged</th>      
                    </tr>
                </thead>
                <tbody>
                    {this.props.miners.map((miner: MinersStore.Miner) =>
                        <tr key={miner.id}>
                            <td>{miner.name}</td>
                            <td>{miner.quantity}</td>
                            <td>{miner.isLogged}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }
   
}

export default connect(
    (state: ApplicationState) => state.miners, // Selects which state properties are merged into the component's props
    MinersStore.actionCreators // Selects which action creators are merged into the component's props
)(FetchData as any);
