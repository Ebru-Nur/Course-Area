import { createSlice } from "@reduxjs/toolkit";
import { addToCart, fetchCartItems, removeFromCart } from "../../services/cart-service";

interface CartItem {
  id: number;
  title: string;
  description: string;
  image: string;
  price: number;
}

interface CartState {
  items: CartItem[];
  status: "idle" | "loading" | "failed";
}

const initialState: CartState = {
  items: [],
  status: "idle",
};

const cartSlice = createSlice({
  name: "cart",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(fetchCartItems.pending, (state) => {
        state.status = "loading";
      })
      .addCase(fetchCartItems.fulfilled, (state, action) => {
        state.status = "idle";
        state.items = action.payload;
      })
      .addCase(fetchCartItems.rejected, (state) => {
        state.status = "failed";
      })
      .addCase(addToCart.fulfilled, (state, action) => {
        state.items.push(action.payload);
      })
      .addCase(removeFromCart.fulfilled, (state, action) => {
        state.items = state.items.filter((item) => item.id !== action.payload);
      });
  },
});

export default cartSlice.reducer;
