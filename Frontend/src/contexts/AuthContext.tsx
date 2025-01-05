import React, { createContext, useContext, useState, ReactNode } from "react";

interface AuthContextProps {
  user: { id: number; role: string; name: string } | null;
  setUser: (user: { id: number; role: string; name: string }) => void;
  logout: () => void;
}

const AuthContext = createContext<AuthContextProps | undefined>(undefined);

export const AuthProvider: React.FC<{ children: ReactNode }> = ({ children }) => {
  const [user, setUserState] = useState<AuthContextProps["user"]>(null);

  const setUser = (user: { id: number; role: string; name: string }) => setUserState(user);
  const logout = () => setUserState(null);

  return <AuthContext.Provider value={{ user, setUser, logout }}>{children}</AuthContext.Provider>;
};

export const useAuth = () => {
  const context = useContext(AuthContext);
  if (!context) {
    throw new Error("useAuth must be used within an AuthProvider");
  }
  return context;
};
