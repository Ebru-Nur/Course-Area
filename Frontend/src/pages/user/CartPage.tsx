import React, { useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import {
  Box,
  Typography,
  Grid,
  Card,
  CardMedia,
  CardContent,
  CardActions,
  Button,
  IconButton,
} from "@mui/material";
import DeleteRoundedIcon from "@mui/icons-material/DeleteRounded";
import { fetchCartItems, removeFromCart } from "services/cart-service";
import { RootState, AppDispatch } from "store";

const CartPage: React.FC = () => {
  const dispatch: AppDispatch = useDispatch();
  const { items, status } = useSelector((state: RootState) => state.cart);

  useEffect(() => {
    dispatch(fetchCartItems());
  }, [dispatch]);

  const handleRemove = (courseId: number) => {
    dispatch(removeFromCart(courseId));
  };

  const calculateTotal = () => {
    return items.reduce((total, item) => total + item.price, 0).toFixed(2);
  };

  const handleCheckout = () => {
    alert("Ödeme işlemi başlatıldı!");
  };

  return (
    <Box sx={{ padding: 3 }}>
      <Typography variant="h4" sx={{ marginBottom: 3, textAlign: "center" }}>
        Sepetiniz
      </Typography>

      {status === "loading" ? (
        <Typography variant="h6" sx={{ textAlign: "center" }}>
          Yükleniyor...
        </Typography>
      ) : items.length === 0 ? (
        <Typography variant="h6" sx={{ textAlign: "center" }}>
          Sepetinizde herhangi bir kurs bulunmamaktadır.
        </Typography>
      ) : (
        <Grid container spacing={2}>
          <Grid item xs={12} md={8}>
            {items.map((item) => (
              <Card
                key={item.id}
                sx={{
                  display: "flex",
                  justifyContent: "space-between",
                  marginBottom: 2,
                  boxShadow: 2,
                }}
              >
                <CardMedia
                  component="img"
                  sx={{ width: 150 }}
                  image={item.image}
                  alt={item.title}
                />
                <CardContent sx={{ flex: 1 }}>
                  <Typography variant="h6">{item.title}</Typography>
                  <Typography variant="body2" color="text.secondary">
                    {item.description}
                  </Typography>
                  <Typography variant="subtitle1" sx={{ marginTop: 1 }}>
                    {item.price} ₺
                  </Typography>
                </CardContent>
                <CardActions>
                  <IconButton color="error" onClick={() => handleRemove(item.id)}>
                    <DeleteRoundedIcon />
                  </IconButton>
                </CardActions>
              </Card>
            ))}
          </Grid>

          <Grid item xs={12} md={4}>
            <Card sx={{ padding: 3, boxShadow: 2 }}>
              <Typography variant="h5" sx={{ marginBottom: 2 }}>
                Toplam Tutar:
              </Typography>
              <Typography variant="h4" color="primary" sx={{ marginBottom: 3 }}>
                {calculateTotal()} ₺
              </Typography>
              <Button
                variant="contained"
                color="primary"
                fullWidth
                size="large"
                onClick={handleCheckout}
              >
                Ödeme Yap
              </Button>
            </Card>
          </Grid>
        </Grid>
      )}
    </Box>
  );
};

export default CartPage;
