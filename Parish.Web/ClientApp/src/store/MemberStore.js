const GET_MEMBERS = 'GET_MEMBERS';
const GET_MEMBERS_SUCCESS = 'GET_MEMBERS_SUCCESS';
const initialState = { familyMembers: [], isLoading: false };

export const memberActions = {
  members: () => async (dispatch) => {
    dispatch({ type: GET_MEMBERS });

    const url = "api/Member";
    const response = await fetch(url);
    const familyMembers = await response.json();

    dispatch({ type: GET_MEMBERS_SUCCESS, familyMembers });
  }
};

export const reducer = (state, action) => {
    state = state || initialState;

    if (action.type === GET_MEMBERS) {
        return {
            ...state,
            isLoading: true
        };
    }

    if (action.type === GET_MEMBERS_SUCCESS) {
        return {
            ...state,
            familyMembers: action.familyMembers,
            isLoading: false
        };
    }

    return state;
};
