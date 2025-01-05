import { ExpandMore } from "@mui/icons-material";
import {
  Box,
  Card,
  CardActions,
  CardHeader,
  CardMedia,
  IconButton,
  Typography,
} from "@mui/material";
import { CourseImg } from "assets";
import AddShoppingCartRoundedIcon from "@mui/icons-material/AddShoppingCartRounded";
import RemoveCircleOutlineRoundedIcon from "@mui/icons-material/RemoveCircleOutlineRounded";
import React from "react";

interface CourseCardProps {
  image: string;
  title: string;
  subheader: string;
  onCartAction: (courseId: number) => void;
  isInCart?: boolean;
  courseId: number;
}

const CourseCard: React.FC<CourseCardProps> = ({
  image,
  title,
  subheader,
  onCartAction,
  isInCart = false,
  courseId,
}) => {
  return (
    <Card
      sx={{
        width: 275,
        height: 320,
        boxShadow: 3,
        transition: "transform 0.3s ease-in-out",
        "&:hover": {
          transform: "scale(1.05)",
        },
      }}
    >
      <Box display="flex" justifyContent="center">
        <CardMedia
          component="img"
          sx={{
            padding: 1,
            borderBottom: "solid 1px #cccccc",
            borderRadius: 2,
            width: "250px",
            boxShadow: 1,
          }}
          image={image}
          alt={title}
        />
      </Box>

      <CardHeader
        title={title}
        subheader={subheader}
        sx={{
          textAlign: "center",
          fontSize: "14px",
        }}
      />

      <CardActions disableSpacing sx={{ justifyContent: "center" }}>
        <IconButton
          sx={{
            padding: 1,
            borderRadius: 2,
          }}
          onClick={() => onCartAction(courseId)}
          color={isInCart ? "error" : "success"}
        >
          {isInCart ? (
            <Box display="flex" flexDirection="row" gap={1} alignItems="center">
              <Typography fontSize={14}>Sepetten Çıkar</Typography>
              <RemoveCircleOutlineRoundedIcon />
            </Box>
          ) : (
            <Box display="flex" flexDirection="row" gap={1} alignItems="center">
              <Typography fontSize={14}>Kayıt Ol</Typography>
              <AddShoppingCartRoundedIcon />
            </Box>
          )}
        </IconButton>
      </CardActions>
    </Card>
  );
};

export default CourseCard;
