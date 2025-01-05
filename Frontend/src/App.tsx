import { Box } from "@mui/material";
import Navbar from "./components/Navbar";
import ProtectedRoute from "contexts/ProtectedContext";
import LoginPage from "pages/auth/LoginPage";
import CoursesPage from "pages/common/CoursesPage";
import ProfilePage from "pages/common/ProfilePage";
import MyCoursesPage from "pages/instructor/MyCoursesPage";
import NewCoursePage from "pages/instructor/NewCoursePage";
import CartPage from "pages/user/CartPage";
import EnrolledCoursesPage from "pages/user/EnrolledCoursesPage";
import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import RegisterPage from "pages/auth/RegisterPage";

const App = () => {
  return (
    <Box p={1}>
      <Router>
        <Navbar />
        <Routes>
          <Route path="/" element={<CoursesPage />} />
          <Route path="/login" element={<LoginPage />} />
          <Route path="/register" element={<RegisterPage />} />

          <Route element={<ProtectedRoute allowedRoles={["instructor"]} />}>
            <Route path="/new-course" element={<NewCoursePage />} />
            <Route path="/my-courses" element={<MyCoursesPage />} />
            <Route path="/profile" element={<ProfilePage />} />
          </Route>

          <Route element={<ProtectedRoute allowedRoles={["student"]} />}>
            <Route path="/cart" element={<CartPage />} />
            <Route path="/enrolled-courses" element={<EnrolledCoursesPage />} />
            <Route path="/profile" element={<ProfilePage />} />
          </Route>
        </Routes>
      </Router>
    </Box>
  );
};

export default App;
