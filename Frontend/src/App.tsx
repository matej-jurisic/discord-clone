import "@mantine/core/styles.css";
import { Group, MantineProvider } from "@mantine/core";
import { Chat } from "./components/Chat";
import { palette } from "./components/pallette";

function App() {
  return (
    <MantineProvider>
      <Group
        style={{
          width: "100wh",
          height: "100vh",
          background: palette.bg,
        }}
      >
        <Chat />
      </Group>
    </MantineProvider>
  );
}

export default App;
