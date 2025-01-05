import React from "react";
import AppBar from "@mui/material/AppBar";
import Toolbar from "@mui/material/Toolbar";
import Typography from "@mui/material/Typography";
import IconButton from "@mui/material/IconButton";
import Menu from "@mui/material/Menu";
import MenuItem from "@mui/material/MenuItem";
import MenuIcon from "@mui/icons-material/Menu";
import Button from "@mui/material/Button";
import { styled } from "@mui/material/styles";
import { Link } from "react-router-dom";
import { useSelector } from "react-redux";
import { RootState } from "../store";
import { Avatar, Badge, Box, Divider, ListItemIcon, Tooltip } from "@mui/material";
import { AppIcon } from "assets";
import { Logout } from "@mui/icons-material";
import ShoppingCartIcon from "@mui/icons-material/ShoppingCart";
const StyledBadge = styled(Badge)(({ theme }) => ({
  "& .MuiBadge-badge": {
    right: -3,
    top: 13,
    border: `2px solid ${theme.palette.background.paper}`,
    padding: "0 4px",
  },
}));
const Navbar: React.FC = () => {
  const { user } = useSelector((state: RootState) => state.user);
  const [isMenuOpen, setMenuOpen] = React.useState(false);

  const handleClickOpen = () => {
    setMenuOpen(!isMenuOpen);
  };

  const publicLinks = [
    { name: "Kurslar", path: "/" },
    // { name: "Login", path: "/login" },
  ];

  const instructorLinks = [
    { name: "Kurslarım", path: "/my-course" },
    { name: "Yeni Kurs", path: "/new-courses" },
    // { name: "Profile", path: "/profile" },
  ];

  const studentLinks = [
    { name: "Kurslarım", path: "/enrolled-courses" },
    // { name: "Profile", path: "/profile" },
  ];

  const renderLinks = () => {
    if (!user) return [];
    if (user.role === "instructor") return instructorLinks;
    if (user.role === "student") return studentLinks;
    return [];
  };

  return (
    <Box
      display={"flex"}
      flexDirection={"row"}
      gap={1}
      padding={"8px 16px 8px 16px"}
      justifyContent={"space-between"}
      boxShadow={2}
      borderRadius={"0px 0px 14px 14px"}
    >
      <Box display={"flex"} flexDirection={"row"} alignItems={"center"} gap={2}>
        <Button size="small" key={"anasayfa"} component={Link} to={"/"}>
          <img style={{ width: "30px" }} alt="app-home" src={AppIcon} />
        </Button>

        <div style={{ display: "flex", gap: "1rem" }}>
          {publicLinks.map((link) => (
            <Button size="small" key={link.name} component={Link} to={link.path}>
              {link.name}
            </Button>
          ))}
        </div>
        <div style={{ display: "flex", gap: "1rem" }}>
          {renderLinks().map((link) => (
            <Button size="small" key={link.name} component={Link} to={link.path}>
              {link.name}
            </Button>
          ))}
        </div>
      </Box>

      {user?.id ? (
        <Box
          display={"flex"}
          flexDirection={{ xs: "column", sm: "row" }}
          alignItems={"center"}
          gap={{ xs: 1, sm: 2 }}
        >
          <Button size="small" key={"login-btn"} component={Link} to={"/login"}>
            Giriş
          </Button>
          <Button
            size="small"
            key={"register-btn"}
            component={Link}
            to={"/register"}
            variant={"contained"}
          >
            Kayıt Ol
          </Button>
        </Box>
      ) : (
        <Box>
          <IconButton aria-label="cart">
            <StyledBadge badgeContent={4} color="secondary">
              <ShoppingCartIcon />
            </StyledBadge>
          </IconButton>
          <Tooltip title="Account settings">
            <IconButton
              onClick={handleClickOpen}
              size="small"
              sx={{ ml: 2 }}
              aria-controls={isMenuOpen ? "account-menu" : undefined}
              aria-haspopup="true"
              aria-expanded={isMenuOpen ? "true" : undefined}
            >
              <Avatar sx={{ width: 32, height: 32 }} />
            </IconButton>
          </Tooltip>
          <Menu
            id="account-menu"
            open={isMenuOpen}
            onClose={handleClickOpen}
            onClick={handleClickOpen}
            slotProps={{
              paper: {
                elevation: 0,
                sx: {
                  overflow: "visible",
                  filter: "drop-shadow(0px 2px 8px rgba(0,0,0,0.32))",
                  mt: 1.5,
                  "& .MuiAvatar-root": {
                    width: 32,
                    height: 32,
                    ml: -0.5,
                    mr: 1,
                  },
                  "&::before": {
                    content: '""',
                    display: "block",
                    position: "absolute",
                    top: 0,
                    right: 14,
                    width: 10,
                    height: 10,
                    bgcolor: "background.paper",
                    transform: "translateY(-50%) rotate(45deg)",
                    zIndex: 0,
                  },
                },
              },
            }}
            transformOrigin={{ horizontal: "right", vertical: "top" }}
            anchorOrigin={{ horizontal: "right", vertical: "bottom" }}
          >
            <MenuItem onClick={handleClickOpen}>
              <Avatar /> Hesabım
            </MenuItem>
            <Divider />

            <MenuItem onClick={handleClickOpen}>
              <ListItemIcon>
                <Logout fontSize="small" />
              </ListItemIcon>
              Çıkış
            </MenuItem>
          </Menu>
        </Box>
      )}
    </Box>

    // <AppBar position="static">
    //   <Toolbar>

    //     <Menu
    //       anchorEl={anchorEl}
    //       open={isMenuOpen}
    //       onClose={handleMenuClose}
    //       sx={{ display: { xs: "block", md: "none" } }}
    //     >
    //       {renderLinks().map((link) => (
    //         <MenuItem key={link.name} component={Link} to={link.path} onClick={handleMenuClose}>
    //           {link.name}
    //         </MenuItem>
    //       ))}
    //     </Menu>
    //   </Toolbar>
    // </AppBar>
  );
};

export default Navbar;
