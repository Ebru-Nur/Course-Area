import CourseCard from "../../components/CourseCard";
import { Grid2 } from "@mui/material";
import React from "react";

const mockCourses = [
  {
    id: 1,
    image: "https://placehold.co/600x400",
    title: "React for Beginners",
    subheader: "September 14, 2023",
    isInCart: false,
  },
  {
    id: 2,
    image: "https://placehold.co/600x400",
    title: "Advanced TypeScript",
    subheader: "October 5, 2023",
    isInCart: true,
  },
  {
    id: 2,
    image: "https://placehold.co/600x400",
    title: "Advanced TypeScript",
    subheader: "October 5, 2023",
    isInCart: true,
  },
  {
    id: 2,
    image: "https://placehold.co/600x400",
    title: "Advanced TypeScript",
    subheader: "October 5, 2023",
    isInCart: true,
  },
  {
    id: 2,
    image: "https://placehold.co/600x400",
    title: "Advanced TypeScript",
    subheader: "October 5, 2023",
    isInCart: true,
  },
  {
    id: 2,
    image: "https://placehold.co/600x400",
    title: "Advanced TypeScript",
    subheader: "October 5, 2023",
    isInCart: true,
  },
];

const CoursesPage: React.FC = () => {
  const handleCartAction = (courseId: number) => {
    console.log(`Course ${courseId} action triggered`);
  };

  return (
    <Grid2 container spacing={2} justifyContent="center" padding={{ xs: 1, sm: 2 }}>
      {mockCourses.map((course) => (
        <CourseCard
          image={course.image}
          title={course.title}
          subheader={course.subheader}
          onCartAction={handleCartAction}
          isInCart={course.isInCart}
          courseId={course.id}
        />
      ))}
    </Grid2>
  );
};

export default CoursesPage;
