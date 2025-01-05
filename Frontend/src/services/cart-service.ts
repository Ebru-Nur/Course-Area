import { createAsyncThunk } from "@reduxjs/toolkit";
import axiosInstance from "./axios-instance";

export const fetchCartItems = createAsyncThunk("cart/fetchCartItems", async () => {
  const response = await axiosInstance.get("/cart");
  return response.data;
});

export const addToCart = createAsyncThunk("cart/addToCart", async (courseId: number) => {
  const response = await axiosInstance.post(`/cart`, { courseId });
  return response.data;
});

export const removeFromCart = createAsyncThunk("cart/removeFromCart", async (courseId: number) => {
  await axiosInstance.delete(`/cart/${courseId}`);
  return courseId;
});
