import { Box, Group, Stack, Text } from "@mantine/core";
import { palette } from "./pallette";

function Avatar() {
  return (
    <Box
      style={{
        width: 40,
        aspectRatio: 1,
        borderRadius: "50%",
        color: palette.green,
        background: palette.greenbg,

        display: "flex",
        alignItems: "center",
        justifyContent: "center",

        fontWeight: 700,
        cursor: "pointer",

        userSelect: "none",
      }}
    >
      DJ
    </Box>
  );
}

export function ChatMessage() {
  return (
    <Group align="flex-start">
      <Avatar />

      <Stack gap={0} style={{ flex: 1 }}>
        <Group align="baseline">
          <Text style={{ color: palette.green, fontWeight: 600 }}>Dorijan</Text>
          <Text size="xs" style={{ color: palette.muted }}>
            {" "}
            Today at 10:31 AM
          </Text>
        </Group>
        <Text style={{ color: palette.text }}>Test. Test. Test.</Text>
      </Stack>
    </Group>
  );
}
