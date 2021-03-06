import { Action, Reducer } from 'redux';
import { AppThunkAction } from '.';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface GoldMineState {
    isLoading: boolean;
    goldMine: GoldMine;
}

export interface GoldMine {
    id: number
    goldLeft: number;    
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.

interface RequestGoldMineAction {
    type: 'REQUEST_GOLDMINE';
}

interface ReceiveGoldMineAction {
    type: 'RECEIVE_GOLDMINE';
    goldMine: GoldMine;
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = RequestGoldMineAction | ReceiveGoldMineAction;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    requestGoldMine: (): AppThunkAction<KnownAction> => (dispatch, getState) => {
        // Only load data if it's something we don't already have (and are not already loading)
        const appState = getState();
        if (appState && appState.goldMine) {            
            fetch(`api/goldmine`)
                .then(response => response.json() as Promise<GoldMine>)
                .then(data => {
                    dispatch({ type: 'RECEIVE_GOLDMINE', goldMine: data });
                });

            dispatch({ type: 'REQUEST_GOLDMINE'});
        }
    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: GoldMineState = { goldMine: { id: 0, goldLeft: 0 }, isLoading: false
};

export const reducer: Reducer<GoldMineState> = (state: GoldMineState | undefined, incomingAction: Action): GoldMineState => {
    if (state === undefined) {
        return unloadedState;
    }

    const action = incomingAction as KnownAction;
    switch (action.type) {
        case 'REQUEST_GOLDMINE':
            return {
                goldMine: state.goldMine,
                isLoading: true
            };
        case 'RECEIVE_GOLDMINE':
            // Only accept the incoming data if it matches the most recent request. This ensures we correctly
            // handle out-of-order responses.
            return {               
                goldMine: action.goldMine,
                isLoading: false
            };
        default:
            break;
    }

    return state;
};
