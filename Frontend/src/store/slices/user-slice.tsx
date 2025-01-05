import { createSlice, PayloadAction } from "@reduxjs/toolkit";

interface UserState {
  user: { id: number; role: string; name: string } | null;
  token: string | null;
}

const initialState: UserState = {
  user: null,
  token: null,
};

const userSlice = createSlice({
  name: "user",
  initialState,
  reducers: {
    setUser: (state, action: PayloadAction<{ id: number; role: string; name: string; token: string }>) => {
      state.user = { id: action.payload.id, role: action.payload.role, name: action.payload.name };
      state.token = action.payload.token;
    },
    logout: (state) => {
      state.user = null;
      state.token = null;
      localStorage.removeItem("token");
    },
  },
});

export const { setUser, logout } = userSlice.actions;
export default userSlice.reducer;
